using Xunit;

public class ValidatorTests
{
    [Fact]
    public void IsValidFormat_ValidFormat_ReturnsTrue()
    {
        // Arrange
        // Skapar ett testvärde med korrekt svenskt personnummerformat: YYYYMMDD-XXXX
        string validInput = "19900101-1234";
        
        // Act 
        // Anropar metoden som validerar formatet
        bool result = Validator.IsValidFormat(validInput);
        
        // Assert 
        // Kontrollerar att resultatet är sant (true)
        // Detta förväntas eftersom formatet är korrekt: 8 siffror, bindestreck, 4 siffror
        Assert.True(result);
    }
}
