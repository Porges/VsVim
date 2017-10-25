﻿using Vim.EditorHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using Vim;
using Vim.UI.Wpf;

namespace Vim.UnitTest
{
    public sealed class TestableProtectedOperations : IProtectedOperations
    {
        private readonly List<Action> _postedActionList = new List<Action>();

        public int PostedActionCount
        {
            get { return _postedActionList.Count; }
        }

        public void RunAll()
        {
            while (_postedActionList.Count > 0)
            {
                _postedActionList[0]();
                _postedActionList.RemoveAt(0);
            }
        }

        #region IProtectedOperations

        Action IProtectedOperations.GetProtectedAction(Action action)
        {
            return action;
        }

        EventHandler IProtectedOperations.GetProtectedEventHandler(EventHandler eventHandler)
        {
            return eventHandler;
        }

        void IProtectedOperations.Report(Exception ex)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
