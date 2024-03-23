﻿using GKS.Web;
using GKS.Web.Components;

namespace GKS.Gastro;

public class DatabaseApiServer : ApiServer
{
    protected override void OnStopRequest(StopEventArgs ea)
    {
        ea.IsAllowed = true;
        ea.IsHandled = true;
        //base.OnStopRequest(ea);
    }
}