namespace Tyrannoport.Models
{
    /// <summary>Outcome of a Test Case</summary>
    public enum TestOutcome
    {
        /// <summary>The test passed</summary>
        Passed,
        
        /// <summary>The test failed</summary>
        Failed,
        
        /// <summary>
        ///   The test wasn't executed. It may have been skipped or ignored
        /// </summary>
        NotExecuted,

        /// <summary>The test neither passed nor failed</summary>
        Other,
    }
}