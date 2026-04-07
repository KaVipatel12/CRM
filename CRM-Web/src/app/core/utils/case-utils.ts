/**
 * Converts an object's keys to camelCase recursively.
 * Useful for handling .NET API responses (PascalCase) in Angular (camelCase).
 */
export function toCamelCase(obj: any): any {
    if (Array.isArray(obj)) {
        return obj.map(v => toCamelCase(v));
    } else if (obj !== null && obj.constructor === Object) {
        return Object.keys(obj).reduce(
            (result, key) => ({
                ...result,
                [key.charAt(0).toLowerCase() + key.slice(1)]: toCamelCase(obj[key]),
            }),
            {},
        );
    }
    return obj;
}
