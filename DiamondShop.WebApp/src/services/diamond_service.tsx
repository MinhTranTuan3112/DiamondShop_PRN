import { customFetch } from "./custom_fetch";

export const fetchPagedDiamonds = async (pageNumber: number = 1,
    pageSize: number = 5,
    sortColumn: string = "id",
    orderByDesc: boolean = false,
    startPrice: number | null = null,
    endPrice: number | null = null,
    cuts: string[] = [],
    colors: string[] = [],
    clarities: string[] = []) => {
    try {

        let url = `/diamonds?pageNumber=${pageNumber}&pageSize=${pageSize}&sortColumn=${sortColumn}&orderByDesc=${orderByDesc}`;

        if (startPrice) {
            url += `&startPrice=${startPrice}`;
        }

        if (endPrice) {
            url += `&endPrice=${endPrice}`;
        }

        if (cuts.length > 0) {
            cuts.forEach(cut => {
                url += `&cuts=${cut}`;
            });
        }

        if (colors.length > 0) {
            colors.forEach(color => {
                url += `&colors=${color}`;
            });
        }

        if (clarities.length > 0) {
            clarities.forEach(clarity => {
                url += `&clarities=${clarity}`;
            });
        }


        const response = await customFetch({
            endpointPath: url,
            options: {
                method: 'GET'
            }
        });

        if (!response.ok) {
            throw new Error(`Failed to fetch diamonds: ${response.statusText}`);
        }

        const data = await response.json();
        console.log('Diamond data:');
        console.log({ data });

        return data;

    } catch (error) {
        console.error(`Error fetching diamonds: ${error}`);
    }
}

export const fetchDiamondDetails = async (id: string) => {
    try {
        
        const response = await customFetch({
            endpointPath: `/diamonds/${id}`,
            options: {
                method: 'GET'
            }
        });

        return response;

    } catch (error) {
        console.error(`Error fetching diamond details: ${error}`);
    }
}