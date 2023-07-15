using System.Text.Json.Serialization;

namespace TraningTrakerApp.Backend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExerciseType
    {
        StrengthTraining ,
        CardiovascularTraining ,
        MobilityTraining ,
        HypertophyTraining 
    }
}