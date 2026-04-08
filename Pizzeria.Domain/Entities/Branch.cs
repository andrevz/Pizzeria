using Pizzeria.Domain.ValueObjects;

namespace Pizzeria.Domain.Entities;

public class Branch : AuditableEntity
{
    private readonly IList<BranchSchedule> _schedules = [];
    
    public string Name { get; private set; }
    public string Address { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public bool IsOpen { get; private set; }

    public IReadOnlyCollection<BranchSchedule> Schedules => _schedules.AsReadOnly();

    protected Branch()
    {
    }

    public void DeleteBranch()
    {
        Delete();
    }

    public void AddBranchSchedule(BranchSchedule branchSchedule)
    {
        ArgumentNullException.ThrowIfNull(branchSchedule);

        if (!_schedules.Contains(branchSchedule))
        {
            _schedules.Add(branchSchedule);
        }
    }

    public void UpdateBranch(string name, string address, PhoneNumber phone, bool isOpen)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        ArgumentNullException.ThrowIfNull(phone);
        
        Name = name;
        Address = address;
        Phone = phone;
        IsOpen = isOpen;
        
        Update();
    }

    private Branch(string name, string address, PhoneNumber phone, bool isOpen)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(address);
        ArgumentNullException.ThrowIfNull(phone);
        
        Name = name;
        Address = address;
        Phone = phone;
        IsOpen = isOpen;
    }

    public static Branch Create(string name, string address, PhoneNumber phone, bool isOpen)
    {
        return new Branch(name, address, phone, isOpen);
    }
}