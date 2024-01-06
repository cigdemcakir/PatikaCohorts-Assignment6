using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQuery
{
    private readonly BookStoreDbContext _context;
    public int AuthorId { get; set; }
    
    private readonly IMapper _mapper;
    
    public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public AuthorDetailViewModel Handle()
    {
        var author = _context.Authors.SingleOrDefault(x=>x.Id== AuthorId);
        
        if(author is null) throw new InvalidOperationException("Yazar bulunamadı");
           
        AuthorDetailViewModel viewModel= _mapper.Map<AuthorDetailViewModel>(author);
        
        return viewModel;
    }
}
public class AuthorDetailViewModel
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string DateOfBirth { get; set; }
}