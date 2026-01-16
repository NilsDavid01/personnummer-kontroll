using Xunit;

namespace PersonnummerValidator.Tests
{
    public class ValidatorTests
    {
        // Tester för att kolla att formatet är rätt (YYYYMMDD-XXXX)
        
        [Theory]
        [InlineData("19900101-1234")]
        [InlineData("20000229-5678")]
        [InlineData("19850615-9999")]
        public void KollarAttRättFormatFungerar(string personnummer)
        {
            // Här testar vi personnummer som ser rätt ut
            var resultat = Validator.IsValidFormat(personnummer);
            
            // Det ska funka!
            Assert.True(resultat);
        }

        [Theory]
        [InlineData("199001011234")]      // Glömt bindestrecket
        [InlineData("19900101-123")]      // För få siffror efter bindestrecket
        [InlineData("19900101-12345")]    // För många siffror efter bindestrecket
        [InlineData("1990101-1234")]      // För få siffror före bindestrecket
        [InlineData("199001011-1234")]    // För många siffror före bindestrecket
        [InlineData("19900101_1234")]     // Använt understreck istället för bindestreck
        [InlineData("19900101 1234")]     // Mellanslag istället för bindestreck
        [InlineData("abcd0101-1234")]     // Bokstäver istället för siffror
        [InlineData("19900101-abcd")]     // Bokstäver i slutet
        [InlineData("")]                   // Tom sträng
        [InlineData("   ")]                // Bara mellanslag
        public void KollarAttFelaktigaFormatInteFungerar(string personnummer)
        {
            // Dessa personnummer är skrivna fel på olika sätt
            var resultat = Validator.IsValidFormat(personnummer);
            
            // Dessa ska inte godkännas
            Assert.False(resultat);
        }

        [Fact]
        public void NullSkaInteFunka()
        {
            // Om nån skickar in null ska det inte krascha
            var resultat = Validator.IsValidFormat(null);
            
            Assert.False(resultat);
        }

        // Tester för att kolla hela personnumret (format + Luhn-algoritmen)

        [Theory]
        [InlineData("19900101-0017")]     // Ett giltigt test-personnummer
        [InlineData("19121212-1212")]     // Klassiskt test-personnummer
        public void RiktgaPersonnummerSkaFungera(string personnummer)
        {
            // Här testar vi med riktiga personnummer som har rätt kontrollsiffra
            var resultat = Validator.IsValidPersonnummer(personnummer);
            
            // Dessa ska godkännas
            Assert.True(resultat);
        }

        [Theory]
        [InlineData("19900101-0018")]     // Rätt format men fel kontrollsiffra
        [InlineData("20000229-2380")]     // Rätt format men fel kontrollsiffra
        [InlineData("19850615-1111")]     // Rätt format men fel kontrollsiffra
        public void FelKontrollsiffraSkaInteGodkännas(string personnummer)
        {
            // Dessa ser rätt ut men har fel sista siffror
            var resultat = Validator.IsValidPersonnummer(personnummer);
            
            // Dessa ska inte godkännas
            Assert.False(resultat);
        }

        [Theory]
        [InlineData("199001011234")]      // Fel format
        [InlineData("19900101-123")]      // Fel format
        [InlineData("")]                   // Tom sträng
        [InlineData("abcd0101-1234")]     // Bokstäver
        public void OmFormatetÄrFelSkaDetInteGodkännas(string personnummer)
        {
            // Om personnumret inte ens ser rätt ut ska det såklart inte funka
            var resultat = Validator.IsValidPersonnummer(personnummer);
            
            Assert.False(resultat);
        }

        [Fact]
        public void NullPersonnummerSkaInteGodkännas()
        {
            // Om nån skickar in null
            var resultat = Validator.IsValidPersonnummer(null);
            
            Assert.False(resultat);
        }

        // Specialfall och verifiering av Luhn-algoritmen

        [Theory]
        [InlineData("19000101-0000")]     // Gammalt datum från 1900
        [InlineData("20991231-9999")]     // Datum långt in i framtiden
        public void SpecialfallMedKonstigaDatum(string personnummer)
        {
            // Här kollar vi att valideringen funkar även för udda datum
            // Om de godkänns eller inte beror på om Luhn-algoritmen stämmer
            var resultat = Validator.IsValidPersonnummer(personnummer);
            
            // Vi vill bara att metoden ska returnera nåt utan att krascha
            Assert.IsType<bool>(resultat);
        }

        [Fact]
        public void VerifieraAttLuhnUträkningenStämmer()
        {
            // Här testar vi ett känt giltigt personnummer för att dubbelkolla
            // att vår Luhn-algoritm räknar rätt
            // 
            // Personnummer: 19900101-0017
            // Efter att ta bort första 2 siffrorna: 900101-0017 = 9001010017
            // Luhn-uträkning: 9*2=18→9, 0, 0*2=0, 1, 0*2=0, 1, 0*2=0, 0, 1*2=2, 7
            // Summa: 9+0+0+1+0+1+0+0+2+7 = 20
            // 20 % 10 = 0 vilket betyder att det är giltigt!
            
            var resultat = Validator.IsValidPersonnummer("19900101-0017");
            
            Assert.True(resultat);
        }
    }
}