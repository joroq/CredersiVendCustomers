namespace VendObjects.Tests;

using System;
using VendObjects;



public class CustomerTests
{
    [SetUp]
    public void Setup()
    {

    }

    [TearDown]
    public void TearDown()
    {
        Customers db = new Customers();
        db.RemoveAll();
    }

//Positive tests
    [Test]
    public void AddManyCustomers()
    {
        Customers db = new Customers();
        db.RemoveAll();
        for (int i = 0; i < 100; i++)
        {
            int id = db.NextId();
            db.Add(db.Create(id, "Water Coolers Ltd")
            .SetContact("Jonas Peel")
            .SetMachines(40)
            .SetAddress1("1 River Way")
            .SetAddress2("Uttoxeter")
            .SetAddress3("")
            .SetPostCode("UT5 7HG"));
        }
        Assert.That(db.Count(), Is.EqualTo(100));

    }

    [Test]
    public void AddOneCustomer()
    {
        Customers db = new Customers();
        db.RemoveAll();
        {
            int id = db.NextId();
            db.Add(db.Create(id, "Prickly Cactuses Ltd")
            .SetContact("S Plant")
            .SetMachines(10)
            .SetAddress1("74 Tower Lane")
            .SetAddress2("Isen Industrial Park")
            .SetAddress3("Pocklington")
            .SetPostCode("PO5 2MI"));
        }
        Assert.That(db.Count(), Is.EqualTo(1));

    }

    [Test]
    public void CVCConsoleQueryValidID()
    {
        Customers db = new Customers();
        int id = db.NextId();
        db.Add(db.Create(id, "Castle Acre Storage")
        .SetContact("Eileen Dover")
        .SetMachines(100)
        .SetAddress1("Castle Acre Industrial Park")
        .SetAddress2("Swaffham")
        .SetAddress3("Norfolk")
        .SetPostCode("NF7 2VD"));

        string? name = db.Query(1)?.Name;
        string? address1 = db.Query(1)?.Address1;
        string? address2 = db.Query(1)?.Address2;
        string? address3 = db.Query(1)?.Address3;
        string? postcode = db.Query(1)?.PostCode;
        string? contact = db.Query(1)?.Contact;
        int machines = db.Query(1).Machines;
        string? category = db.Query(1)?.Category;

        Assert.That(name, Is.EqualTo("Castle Acre Storage"));
        Assert.That(address1, Is.EqualTo("Castle Acre Industrial Park"));
        Assert.That(address2, Is.EqualTo("Swaffham"));
        Assert.That(address3, Is.EqualTo("Norfolk"));
        Assert.That(postcode, Is.EqualTo("NF7 2VD"));
        Assert.That(contact, Is.EqualTo("Eileen Dover"));
        Assert.That(machines, Is.EqualTo(100));
        Assert.That(category, Is.EqualTo("Gold"));
    }

//exceptions expected tests
    [Test]
    public void CVCInvalidAddress()
    {
        Customers db = new Customers();
        db.RemoveAll();
        try
        {
            int id = db.NextId();
            db.Add(db.Create(id, "Danny's Desks Ltd")
            .SetContact("Wilf Thompson")
            .SetMachines(3)
            .SetAddress1("")
            .SetAddress2("")
            .SetAddress3("")
            .SetPostCode(""));
            Assert.Fail("Expected exception was not thrown.");

        }
        catch (Exception)
        {

        }
        Assert.That(db.Count(), Is.EqualTo(1));
    }

    [Test]
    public void CVCOnlyOptionalData()
    {
        Customers db = new Customers();
        db.RemoveAll();
        try
        {
            int id = db.NextId();
            db.Add(db.Create(id, "")
            .SetContact("")
            .SetMachines(0)
            .SetAddress1("")
            .SetAddress2("Isen Industrial Park")
            .SetAddress3("Pocklington")
            .SetPostCode(""));

            Assert.Fail("Expected exception was not thrown.");

        }

        catch (Exception)
        {
        }
        Assert.That(db.Count(), Is.EqualTo(1));
    }


    [Test]
    public void CVCAddCustomerNoData()
    {
        Customers db = new Customers();
        db.RemoveAll();
        try
        {
            int id = db.NextId();
            db.Add(db.Create(id, "")
            .SetContact("")
            .SetMachines(0)
            .SetAddress1("")
            .SetAddress2("")
            .SetAddress3("")
            .SetPostCode(""));

            Assert.Fail("Expected exception was not thrown.");

        }

        catch (Exception)
        {

        }
        Assert.That(db.Count(), Is.EqualTo(1));
    }


    

    [Test]
    public void CVCNoIDInDatabase()
    {
        try
        {
            Customers db = new Customers();
            db.Query(78);
            Assert.Fail("Expected exception was not thrown.");

        }
        catch (Exception)
        {
            Assert.Pass();
        }
    }

    [Test]
    public void ClearDatabase()
    {
        Customers db = new Customers();
        db.RemoveAll();
        Assert.That(db.Count(), Is.EqualTo(0));
    }
};


