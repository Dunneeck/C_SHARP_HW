using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_2;

public interface IControllable
{
    bool IsOn { get; }
    void On();
    void Off();
}

