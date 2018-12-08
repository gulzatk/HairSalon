using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{

  [TestClass]
  public class StylistTest : IDisposable
  {

  public StylistTest()
   {
     DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=gulzat_karimova_test;";
   }

   public void Dispose()
    {
      Stylist.ClearAll();
      Item.ClearAll();
    }

    [TestMethod]
   public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
   {
     Stylist newStylist = new Stylist("test category");
     Assert.AreEqual(typeof(Stylist), newStylist.GetType());
   }

   [TestMethod]
   public void GetDescription_ReturnsName_String()
   {
     //Arrange
     string name = "Test Stylist";
     Stylist newStylist = new Stylist(name);

     //Act
     string result = newStylist.GetName();

     //Assert
     Assert.AreEqual(name, result);
   }

   [TestMethod]
   public void GetDescription_ReturnsDescription_String()
   {
     //Arrange
     string description = "Test Stylist";
     Stylist newStylist = new Stylist(description);

     //Act
     string result = newStylist.GetDescription();

     //Assert
     Assert.AreEqual(description, result);
   }

   [TestMethod]
public void GetAll_ReturnsAllStylistObjects_StylistList()
{
  //Arrange
  string name01 = "Anna";
  string name02 = "Emma";
  Stylist newStylist1 = new Stylist(name01);
  newStylist1.Save();
  Stylist newStylist2 = new Stylist(name02);
  newStylist2.Save();
  List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

  //Act
  List<Stylist> result = Stylist.GetAll();

  //Assert
  CollectionAssert.AreEqual(newList, result);
}
  }
}
