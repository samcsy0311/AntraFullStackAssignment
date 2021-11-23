let truncate = function (str, maxLength) {
     if (str.length < maxLength) {
          return str;
     }

     let newStr = str.substring(0, maxLength-1) + '...';
     return newStr;
}

let str = "Hi everyone!"
console.log(truncate(str, 20));