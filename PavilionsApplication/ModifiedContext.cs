using System;
using PavilionsData.PavilionsModel.Context;

namespace PavilionsApplication;

public class ModifiedContext
{

    private PavilionsDbContext context; 
    
    public PavilionsDbContext Context { get => context; }

    public void ReloadContext()
    {
        context = new PavilionsDbContext();
        GC.Collect();
    }

    public ModifiedContext()
    {
        ReloadContext();
    }
}