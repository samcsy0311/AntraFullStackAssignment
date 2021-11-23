var arr = ["James", "Brennie"]
console.log(arr.toString());

arr.push("Robert");
console.log(arr.toString());

let middle = Math.floor(arr.length / 2);
arr[middle] = "Calvin";
console.log(arr.toString());


arr.shift();
console.log(arr.toString());

arr.unshift("Rose", "Regal");
console.log(arr.toString());