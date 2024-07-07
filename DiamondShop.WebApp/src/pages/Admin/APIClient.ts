// APIClient.ts
  export const fetchProducts = async (
    name: string,
    pageNumber: number,
    pageSize: number,
    sortColumn?: string,
    orderByDesc?: boolean
  ): Promise<{ results: any[]; totalCount: number }> => {
    let url = `https://localhost:7054/api/Products?pageNumber=${pageNumber}&pageSize=${pageSize}`;
  
    if (name.trim() !== "") {
      url += `&name=${name}`;
    }
  
    if (sortColumn) {
      url += `&sortColumn=${sortColumn}&orderByDesc=${orderByDesc ? "true" : "false"}`;
    }
  
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }
  
    const data = await response.json();
    const products: any[] = data.results.map((product: any) => ({
      id: product.id,
      name: product.name,
      type: product.type,
      material: product.material,
      price: product.price,
      point: product.point,
      pictures: product.pictures.map((pic: any) => ({
        id: pic.id,
        urlPath: pic.urlPath,
      })),
    }));
  
    return { results: products, totalCount: data.totalCount };
  };
  