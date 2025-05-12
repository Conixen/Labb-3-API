# Labb 3 - API

## Calling of the API:

### 1. Hämta alla personer
**GET** `/api/People`  
🔹 Visar en lista på alla personer i systemet.

---

### 2. Hämta intressen för en specifik person  
**GET** `/api/People/{personId}/interests`  
🔹 Returnerar alla intressen som personen har.

---

### 3. Hämta länkar för en specifik person  
**GET** `/api/People/{personId}/links`  
🔹 Visar alla länkar kopplade till personens intressen.

---

### 4. Koppla en person till ett nytt intresse  
**POST** `/api/People/{personId}/interests/{interestId}`  
🔹 Lägger till ett intresse till personen.  
🔸 Om personen redan har detta intresse, händer inget.

Exempel:
/api/People/{1}/interests/{8} 

---

### 5. Lägg till en ny länk för en specifik person och ett specifikt intresse  
**POST** `/api/People/{personId}/interests/{interestId}/links?url=https://exempel.se`  
🔹 Lägger till en länk till ett specifikt intresse för en person.  
🔸 Som om du använder anrop 4 och ger ett intresse kan du se skicka en länk till den

Exempel:
/api/People/{1}/interests/{8}/links?url=https://Amazon.com
