namespace VendObjects.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }


    //Boundary Value Analysis Tests

    [Test]
    public void NameLead()
    {   
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(0);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Lead"));
    }
    [Test]
    public void NameAluminium1()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(1);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Aluminium"));
    }
    [Test]
    public void NameAluminium2()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(2);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Bronze"));
    }
    [Test]
    public void NameAluminium3()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(5);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Bronze"));
    }
    [Test]
    public void NameSilver1()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(6);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Silver"));
    }
    [Test]
    public void NameSilver2()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(7);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Silver"));
    }
    [Test]
    public void NameSilver3()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(19);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Silver"));
    }
    [Test]
    public void NameGold1()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(20);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Gold"));
    }
    [Test]
    public void NameGold2()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(21);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Gold"));
    }
    [Test]
    public void NameGold3()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(199);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Gold"));
    }
    [Test]
    public void NamePlatinum1()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(200);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Platinum"));
    }
    [Test]
    public void NamePlatinum2()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        Customer db = new Customer(99, "Name");
        db.SetContact("Contact");
        db.SetMachines(201);
        db.SetAddress1("Address 1");
        db.SetAddress2("Address 2");
        db.SetAddress3("Address 3");
        db.SetPostCode("PostCode");
        Assert.That(db.Category, Is.EqualTo("Platinum"));
    }


    //Standard Functionality Tests
    [Test]
    public void Add10Customers()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        for(int i = 0; i < 10; i++)
        {
            int id = customers.NextId();
            customers.Add(customers.Create(id, "Name")
                .SetContact("Contact")
                .SetMachines(i)
                .SetAddress1("Address 1")
                .SetAddress2("Address 2")
                .SetAddress3("Address 3")
                .SetPostCode("PostCode")
            );
        }
        Assert.That(customers.Count(), Is.EqualTo(10));
    }
    [Test]
    public void AddCustomer()
    {
        Customers customers = new Customers();
        customers.RemoveAll();
        customers.Add(customers.Create(0, "")
            .SetContact("")
            .SetMachines(0)
            .SetAddress1("")
            .SetAddress2("")
            .SetAddress3("")
            .SetPostCode(""));
        Assert.That(customers.Count(), Is.EqualTo(1));
    }
    
    [Test]
    public void Query()
    {
        Customers db = new Customers();
        db.RemoveAll();
        Customer customer = new Customer(101, "Name")
            .SetContact("Contact")
            .SetMachines(1)
            .SetAddress1("Address 1")
            .SetAddress2("Address 2")
            .SetAddress3("Address 3")
            .SetPostCode("PostCode");
        db.Add(customer);
        Assert.That(customer.Id, Is.EqualTo(101));
        Assert.That(customer.Name, Is.EqualTo("Name"));
        Assert.That(customer.Contact, Is.EqualTo("Contact"));
        Assert.That(customer.Machines, Is.EqualTo(1));
        Assert.That(customer.Address1, Is.EqualTo("Address 1"));
        Assert.That(customer.Address2, Is.EqualTo("Address 2"));
        Assert.That(customer.Address3, Is.EqualTo("Address 3"));
        Assert.That(customer.PostCode, Is.EqualTo("PostCode"));
        Assert.That(customer.Category, Is.EqualTo("Aluminum"));
        db.RemoveAll();
    }
     [Test]
    public void AddCustomers()
    {
        Customers db = new Customers();
        db.RemoveAll();
        //int id = db.NextId();
        db.Add(db.Create(888888, "Name")
            .SetContact("Contact")
            .SetMachines(1)
            .SetAddress1("Address 1")
            .SetAddress2("Address 2")
            .SetAddress3("Address 3")
            .SetPostCode("PostCode"));
        db.Add(db.Create(888889, "Name")
            .SetContact("Contact")
            .SetMachines(1)
            .SetAddress1("Address 1")
            .SetAddress2("Address 2")
            .SetAddress3("Address 3")
            .SetPostCode("PostCode"));
        Assert.That(db.Count(), Is.EqualTo(2));
    }
    [Test]
     public void NextID()
    {
        Customers db = new Customers();
        db.RemoveAll();
            db.Add(db.Create(888888, "Name")
            .SetContact("Contact")
            .SetMachines(1)
            .SetAddress1("Address 1")
            .SetAddress2("Address 2")
            .SetAddress3("Address 3")
            .SetPostCode("PostCode"));
        Assert.That(db.NextId(), Is.EqualTo(888889));
    }
}