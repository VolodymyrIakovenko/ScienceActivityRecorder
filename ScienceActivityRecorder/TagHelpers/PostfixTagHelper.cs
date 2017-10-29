using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ScienceActivityRecorder.TagHelpers
{
    [HtmlTargetElement("label", Attributes = _textAttributeName)]
    public class PostfixTagHelper : TagHelper
    {
        private const string _textAttributeName = "postfix-text";

        [HtmlAttributeName(_textAttributeName)]
        public string Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.Content.Append(Text);
        }

        public override int Order
        {
            get
            {
                return 100; // Needs to run after aspnet
            }
        }
    }
}
