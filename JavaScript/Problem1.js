let salaries = {
     John: 100,
     Ann: 160,
     Pete: 130
};

const sumValues = obj => Object.values(obj).reduce((a, b) => a + b);
let sum = sumValues(salaries);

console.log(sum);

