export const listProduct = async (page: number, startPrice: number, endPrice: number) => {
  const response = await fetch(`https://localhost:7054/api/Products?QueryDto.PageNumber=${page}&StartPrice=${startPrice}&EndPrice=${endPrice}`);
  if (!response.ok) {
    throw new Error("Failed to fetch products");
  }
  return await response.json();
};
