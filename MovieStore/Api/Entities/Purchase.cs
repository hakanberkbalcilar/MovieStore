namespace MovieStore.Api.Entities;

public class Purchase
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }


    public User User { get; set; } = null!;
    public Movie Movie { get; set; } = null!;
}