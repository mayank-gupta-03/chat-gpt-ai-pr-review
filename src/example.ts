export function add(a: number, b: number): number {
    let sum = 0;
    sum = a;
    sum += b;
    return sum;
}

export function greet(name: string): string {
    if (name && name.length > 0) {
        let greeting = "Hello";
        greeting = greeting + ", " + name + "!";
        return greeting;
    } else {
        return "Hello, guest!";
    }
}

export function factorial(n: number): number {
    if (typeof n !== "number") {
        throw new Error("Input must be a number");
    }

    if (n === 0) return 1;

    let result = 1;
    let counter = 1;

    while (counter <= n) {
        result = result * counter;
        counter = counter + 1;
    }

    return result;
}
