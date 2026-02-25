namespace Tests;

using System.Reflection;
using System.Text.RegularExpressions;
using knightmoves;
using Xunit;

public class AutogradingTest
{
  /*
should simplify if/else statement in `LookUpBranding` using a ternary operator
  */

    [Fact]
    public void Should_Simplify_The_If_Else_Statement_In_LookUpBranding_Method_Using_A_Ternary_Operator(){
      var organization = new Organization("test");
      
      Assert.Equal("test est. 1934", organization.LookUpBranding(includeYearEstablished: true));
      Assert.Equal("test", organization.LookUpBranding(includeYearEstablished: false));

      string filePath = Path.GetDirectoryName(typeof(Organization).Assembly.Location) + "/../../../Organization.cs";

      Assert.True(File.Exists(filePath), "File does not exist");

      string content = File.ReadAllText(filePath);
      Regex rx = new Regex(@"includeYearEstablished.*\?.*\:.*;");

      bool hasComment = rx.IsMatch(content);

      Assert.True(hasComment, "Should simplify the if/else statement in `LookUpBranding` method using a ternary operator");

    }
}