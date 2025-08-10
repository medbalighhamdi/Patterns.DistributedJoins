public record ProductJoinControls
{
    public bool IncludeUser { get; init; } = false;
    public bool IncludeRating { get; init; } = false;

    private ProductJoinControls()
    {
        IncludeUser = false;
        IncludeRating = false;
    }
    public static ProductJoinControls Initiate()
    {
        return new ProductJoinControls();
    }

    public ProductJoinControls InnerJoinUsers()
    {
        return this with { IncludeUser = true };
    }

    public ProductJoinControls InnerJoinRatings()
    {
        return this with { IncludeRating = true };
    }   
}