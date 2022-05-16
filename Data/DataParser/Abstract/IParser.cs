namespace CRUD_Fornecedores.Data.DataParser.Abstract
{
    public interface IParser<TInput,TOutput>
    {
        TOutput Parse(TInput input);
        List<TOutput> Parse(List<TInput> input);

        TInput Parse(TOutput input);
        List<TInput> Parse(List<TOutput> input);
    }
}
