using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace GerenciadorEstoque.ValidationAnnotations
{
  public class DataCartaoCred : ValidationAttribute
  {
    public override bool IsValid(object? dtExpiracao)
    {

            var rx = new Regex(@"^((0[1-9])|(1[0-2]))\/(\d{4})$");
            if(dtExpiracao is not null && rx.IsMatch(dtExpiracao.ToString()!))
            {
               
               var data = dtExpiracao.ToString()!.Split("/");
                var mes = int.Parse(data[0]);
                var ano = int.Parse(data[1]);
                
                var hoje = DateTime.Now;

              return hoje.Year <= ano && (hoje.Year != ano || hoje.Month <= mes);

            }
            else
            {
              return false;
            }
    }

  }
}