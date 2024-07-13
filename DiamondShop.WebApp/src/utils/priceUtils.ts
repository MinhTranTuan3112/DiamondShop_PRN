export function formatPrice(price: number | undefined): string {
    return (price === undefined) ? '' : price.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ".");
}

export const getRingSizePrice = (ringSize: number, material: string) => {
    let sumSizePrice = 0;

    if (ringSize < 10) {
        sumSizePrice = 1000000;
    } else if (ringSize < 18) {
        sumSizePrice = 2000000;
    } else if (ringSize <= 23) {
        sumSizePrice = 3000000;
    } else {
        sumSizePrice = 4000000;
    }

    return material === 'Platinum' ? sumSizePrice * 2 : sumSizePrice;
};