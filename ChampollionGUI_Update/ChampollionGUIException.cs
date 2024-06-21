using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampollionGUI_Update
{
    //TODO: Create exeption for when something not fitting any of the exceptions
    //below happens. E.g. when trying to open the readme_instructions.txt file,
    //but that file is missing, or when some input fields have been left blank
    [Serializable]
    public class ChampollionGUIException : Exception
    {
        public ChampollionGUIException(String ErrorMessage) 
            : base(ErrorMessage)
        { }
    }

    ///***********************************************************************
    /// <summary>
    /// The class represents an exception that is thrown to indicate that not
    /// all dependencies to run Champollion (or the GUI) were satisified. In
    /// most cases, it is thrown when there is a missing file (or multiple) or
    /// when the C++ Redistributeables were not installed.
    /// </summary>
    ///***********************************************************************
    public class DependencyException : ChampollionGUIException
    {
        ///***********************************************************************
        /// <summary>
        /// A new exception is constructed with the error message ErrorMessage.
        /// </summary>
        /// <param name="ErrorMessage">
        /// The error message of the exception.
        /// </param>
        ///***********************************************************************
        public DependencyException(String ErrorMessage)
            : base(ErrorMessage)
        { }
    }

    ///***********************************************************************
    /// <summary>
    /// The class represents an exception that is thrown to indicate that not
    /// all conditions were satisfied for the program to start the process of
    /// decompiling the .pex files. In most cases, it is thrown when there is
    /// an issue with a folder that the user has specified.
    /// </summary>
    ///***********************************************************************
    public class PreDecompilationException : ChampollionGUIException
    {
        ///***********************************************************************
        /// <summary>
        /// A new exception is constructed with the error message ErrorMessage.
        /// </summary>
        /// <param name="ErrorMessage">
        /// The error message of the exception.
        /// </param>
        ///***********************************************************************
        public PreDecompilationException(String ErrorMessage)
            : base(ErrorMessage)
        { }
    }

    ///***********************************************************************
    /// <summary>
    /// The class represents an exception that is thrown to indicate that the
    /// decompilation process ran into an error during excecution ( In most 
    /// cases, it is thrown when there is an issue with a folder that the user
    /// has specified.
    /// </summary>
    ///***********************************************************************
    public class IntraDecompilationException : ChampollionGUIException
    {
        ///***********************************************************************
        /// A new exception is constructed with the error message ErrorMessage.
        /// </summary>
        /// <param name="ErrorMessage">
        /// The error message of the exception.
        /// </param>
        ///***********************************************************************
        public IntraDecompilationException(String ErrorMessage)
            : base(ErrorMessage)
        { }
    }

    ///***********************************************************************
    /// <summary>
    /// The class represents an exception that is thrown to indicate that the
    /// program ran into an error, but the nature of the error does not fit
    /// any of the previously described categories, i.e. the error is not
    /// related to missing dependencies, an error thrown during the pre
    /// decompilation checks or during the decompilation process.
    /// </summary>
    ///***********************************************************************
    public class DefaultCGUIException : ChampollionGUIException
    {
        ///***********************************************************************
        /// A new exception is constructed with the error message ErrorMessage.
        /// </summary>
        /// <param name="ErrorMessage">
        /// The error message of the exception.
        /// </param>
        ///***********************************************************************
        public DefaultCGUIException(String ErrorMessage)
            : base(ErrorMessage)
        {
        }
    }
}
