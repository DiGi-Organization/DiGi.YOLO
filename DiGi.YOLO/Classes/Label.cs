using System.Globalization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents a label associated with an object detection class in YOLO.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// The numerical index of the label.
        /// </summary>
        public int index;

        /// <summary>
        /// The descriptive name of the label.
        /// </summary>
        public string? name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="index">The numerical index for the label.</param>
        /// <param name="name">The descriptive name for the label.</param>
        public Label(int index, string? name)
        {
            this.index = index;
            this.name = name;
        }

        /// <summary> Gets the numerical index of the label. </summary>
        public int Index
        {
            get
            {
                return index;
            }
        }

        /// <summary> Gets the descriptive name of the label. </summary>
        public string? Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current label based on its string representation.
        /// </summary>
        /// <param name="object">The object to compare with the current label.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object @object)
        {
            return @object != null && @object.GetType() == GetType() && ToString() == @object.ToString();
        }

        /// <summary>
        /// Returns a hash code for the current label based on its string representation.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current label.
        /// </summary>
        /// <returns>A string containing the index and name of the label.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}: {1}", index, name ?? string.Empty);
        }
    }
}