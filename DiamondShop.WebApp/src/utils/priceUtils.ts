export function formatPrice(price: number | undefined): string {
    return (price === undefined) ? '' : price.toFixed(0).replace(/\B(?=(\d{3})+(?!\d))/g, ".");
}