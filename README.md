# Personnummerkontroll

Detta är en enkel **C#-konsolapplikation** som kontrollerar svenska personnummer.

---

## Funktionalitet

- Programmet frågar användaren om ett personnummer i formatet `YYYYMMDD-XXXX`.
- Kontrollerar att formatet är korrekt med **regex**.
- Validerar personnumret med **Luhn-algoritmen**.
- Returnerar om personnumret är korrekt eller ogiltigt.

---

## Svenska regler för personnummer

- Ett svenskt personnummer består av **år, månad, dag + fyrsiffrig identitet**: `YYYYMMDD-XXXX`.
- De fyra sista siffrorna används bland annat för kön och kontrollsiffra.
- Kontrollsiffran verifieras med **Luhn-algoritmen**:
  1. Varannan siffra multipliceras med 2, resten med 1.
  2. Om en produkt blir större än 9, subtrahera 9.
  3. Summan av alla siffror ska vara delbar med 10 för att numret ska vara giltigt.

---

## Kör programmet lokalt

1. Klona repot och byt till din branch:

```bash
git clone <repo-url>
cd personnummer-kontroll 
```

2. Bygg och kör programmet:

```bash
dotnet build
dotnet run
```

3. Ange ett personnummer när programmet frågar, t.ex. `20010101-1237`.

4. Programmet svarar om numret är korrekt eller ogiltigt.

---

## Docker
- För att köra applikationen i Docker:
- Instruktioner för att bygga och köra Docker-containern kommer att läggas till senare.
