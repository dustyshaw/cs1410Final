namespace MyLibrary.lib;

public enum ItemAvailability
{
    CheckedIn,          //available for check out or can be placed on hold, not assigned to any patron
    CheckedOut,         //checked out and assigned to a patron, unavailable to other patrons
    OnHold,             //unavailable for check out, being held for a patron
    LostorStolen,       //marked as lost or stolen after a certain period of being overdue or checked out
    Pending,            // bought but not available yet, being repaired by library
    Unavailable = LostorStolen | CheckedOut | Pending,   //unavailable for checkout, but could fullfill these categories
}
