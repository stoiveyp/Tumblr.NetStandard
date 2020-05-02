using System.Runtime.Serialization;

namespace Tumblr.NetStandard.NPF.ContentBlocks
{
    public enum TextSubtype
    {
        [EnumMember(Value="heading1")] Heading1,
        [EnumMember(Value="heading2")] Heading2,
        [EnumMember(Value="quirky")] Quirky,
        [EnumMember(Value="quote")] Quote,
        [EnumMember(Value="indented")] Indented,
        [EnumMember(Value="chat")] Chat,
        [EnumMember(Value="ordered-list-item")] OrderedListItem,
        [EnumMember(Value="unordered-list-item")] UnorderedListItem
    }
}