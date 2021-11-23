let validateCard = function (cardsToValidate, bannedPrefixes) {
     let resultArr = [];
     for (j = 0; j < cardsToValidate.length; j++) {
          let cardNo = cardsToValidate[j];
          let valid = isValid(cardNo);
          let allowed = isAllowed(cardNo, bannedPrefixes);

          let obj = {
               card: cardNo,
               isValid: valid,
               isAllowed: allowed
          };
          resultArr.push(obj);
     }
     return JSON.stringify(resultArr);
}

let isValid = function (cardNo) {
     let sum = 0;
     for (i = 0; i < cardNo.length - 1; i++) {
          sum += cardNo[i] * 2;
     }
     return cardNo % 10 == cardNo[cardNo.length - 1];
}

let isAllowed = function (cardNo, bannedPrefixes) {
     for (i = 0; i < bannedPrefixes.length; i++) {
          let len = bannedPrefixes[i].length;
          if (cardNo.substring(0, len) == bannedPrefixes[i]) {
               return false;
          }
     }
     return true;
}

let cardsToValidate = ["6724843711060148", "1124843711060148"];
let bannedPrefixes = [ "11", "3434", "67453", "9"];
validateCard(cardsToValidate, bannedPrefixes);