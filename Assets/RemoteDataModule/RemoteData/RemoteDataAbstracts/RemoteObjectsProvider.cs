﻿using UnityEngine;
using System.Collections;
using System;

namespace GBG.Modules.RemoteData.RemoteDataAbstracts
{
    public abstract class RemoteObjectsProvider : IDisposable
    {
        public abstract void Dispose();

        public abstract RemoteObjectHandler<T> GetRemoteObject<T>(string path) where T : class;

        public abstract string GetIdForNewObject(string path);
    }
}
