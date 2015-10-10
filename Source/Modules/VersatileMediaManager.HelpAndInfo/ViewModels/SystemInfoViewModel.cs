using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using VersatileMediaManager.HelpAndInfo.SystemInfo;
using VersatileMediaManager.Infrastructure.Base;

namespace VersatileMediaManager.HelpAndInfo.ViewModels
{
    public class SystemInfoViewModel : VersatileMediaManagerPopupViewModel
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public SystemInfoViewModel()
        {
            this.OperatingSystem = OSVersionInfo.OsVersionCompleteString;
            this.InstalledNetFrameworkVersions = DotNetFrameworkInfo.InstalledDotNetVersions();

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                if (System.IO.Path.GetFileName(dll).StartsWith("VersatileMediaManager"))
                {
                    var assembly = Assembly.LoadFile(dll);
                    this.ApplicationAssemblies.Add(new ApplicationDll()
                    {
                        Name = assembly.GetName().Name + ".dll",
                        Version = assembly.GetName().Version.ToString(),
                        Description = ((AssemblyDescriptionAttribute)assembly.GetCustomAttribute(typeof(AssemblyDescriptionAttribute))).Description
                    });
                }
            }
        }

        /// <summary>
        /// Title
        /// </summary>
        public override string Title
        {
            get
            {
                return "System-Information";
            }
        }

        #region Properties

        private string operationSystem;

        /// <summary>
        /// Operating system
        /// </summary>
        public string OperatingSystem
        {
            get { return operationSystem; }
            private set { this.SetProperty<string>(ref this.operationSystem, value); }
        }

        private IList<DotNetFrameworkInfo.NetFrameworkVersionInfo> installedNetFrameworkVersions;

        /// <summary>
        /// List with installed .NET Framework versions
        /// </summary>
        public IList<DotNetFrameworkInfo.NetFrameworkVersionInfo> InstalledNetFrameworkVersions
        {
            get { return installedNetFrameworkVersions; }
            private set { this.SetProperty<IList<DotNetFrameworkInfo.NetFrameworkVersionInfo>>(ref this.installedNetFrameworkVersions, value); }
        }

        /// <summary>
        /// Application version
        /// </summary>
        public string ApplicationVersion
        {
            get { return String.Format("{0} ({1})", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name); }
        }

        private IList<ApplicationDll> applicationAssemblies = new List<ApplicationDll>();

        /// <summary>
        /// Application assemblies
        /// </summary>
        public IList<ApplicationDll> ApplicationAssemblies
        {
            get { return applicationAssemblies; }
            set { this.SetProperty<IList<ApplicationDll>>(ref this.applicationAssemblies, value); }
        }

        #endregion Properties
    }

    public class ApplicationDll
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }
}