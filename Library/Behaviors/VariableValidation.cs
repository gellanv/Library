using System.ComponentModel.DataAnnotations;

namespace Library.Behaviors
{
    public class VariableValidation
    {
        public void CheckId(int id, string message)
        {
            if (id <= 0)
            {
                throw new ValidationException($"{message}{id} isn't valid");
            }
        }

        public void CheckScore(int score)
        {
            if (score < 1 || score > 5)
            {
                throw new ValidationException($"Score {score} isn't valid");
            }
        }

        public void CheckObjectForNull(object instance, string message)
        {
            if (instance == null)
            {
                throw new ValidationException($"The {message} wasn't found");
            }
        }
    }
}
