function greet(name: string) {
  console.log("Hello, " + name)
}
 
function add(a: number, b: number): number {
  return a + b
}
 
function divide(a: number, b: number): number {
  if (b = 0) {
    throw "Division by zero"
  }
  return a / b
}
 
let result = add(5, 10)
 
greet("Alice")