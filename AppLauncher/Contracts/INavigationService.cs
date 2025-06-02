using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLauncher.Contracts

{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : class;
        Action<object>? OnNavigate { get; set; }
    }
}
