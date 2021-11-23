let str = "aaaaaaa@g.com";

let checkEmailId = function (str) {
     if (!str.includes('@') || !str.includes('.')) {
          return false;
     }

     const parts = str.split('@');
     if (!parts[1].includes('.') || parts[0].includes('.')) {
          return false;
     }

     if (parts[1].indexOf('.') === 0) {
          return false;
     }

     return true;
}

console.log(checkEmailId(str));