using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {


        public static IHtmlString DropDownCustom(this HtmlHelper helper)
        {



            //          <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
            //  <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Action</a></li>
            //  <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Another action</a></li>
            //  <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Something else here</a></li>
            //  <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Separated link</a></li>
            //</ul>

            // Build <img> tag
            TagBuilder ul = new TagBuilder("ul");
            // Add "src" attribute
            //tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            // Add "alt" attribute
            //tb.Attributes.Add("alt", alt);
            // return MvcHtmlString. This class implements IHtmlString
            // interface. IHtmlStrings will not be html encoded.

            ul.Attributes.Add("class", "dropdown-menu");
            ul.Attributes.Add("role", "menu");
            ul.Attributes.Add("aria-labelledby", "dropdownMenu1");

            for (int i = 0; i < 5; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.Attributes.Add("role", "presentation");
                li.InnerHtml = "Option" + i;

                ul.InnerHtml += li.ToString(TagRenderMode.Normal);
            }






            return new MvcHtmlString(ul.ToString(TagRenderMode.Normal));

        }

        public static MvcHtmlString LinkedDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string parent, IEnumerable<LinkedSelectListItem> selectList)
        {
            string propertyName = ((MemberExpression)expression.Body).Member.Name;

            TagBuilder select = new TagBuilder("select");
            select.Attributes.Add("id", propertyName);
            select.Attributes.Add("name", propertyName);
            select.Attributes.Add("class", "linked-dropdown");
            select.Attributes.Add("data-parent", parent);

            foreach (var item in selectList)
            {
                TagBuilder option = new TagBuilder("option");
                option.InnerHtml = item.Text;
                option.Attributes.Add("value", item.Value);
                option.Attributes.Add("data-parentvalue", item.LinkValue);

                if (item.Selected)
                {
                    option.Attributes.Add("selected", "selected");
                }
                select.InnerHtml += option.ToString(TagRenderMode.Normal);
            }

            string script = @"<script type='text/javascript'>$(document).ready(function () {
								$('#' + $('.linked-dropdown').attr('data-parent')).unbind('change.linked-dropdown');

								$('.linked-dropdown').each(function () {
									var $linked = $(this);

									$('#' + $linked.attr('data-parent')).bind('change.linked-dropdown', function () {
										var parentid = $(this).find('option:selected').val();

										$linked.find('option').hide();
										$linked.find('option[data-parentvalue=' + parentid + ']').show();
										$linked.find('option:visible:first').attr('selected', 'selected');
									});

									$('#' + $linked.attr('data-parent')).change();
								});
							});</script>";

            return MvcHtmlString.Create(script + select.ToString(TagRenderMode.Normal));
        }

        /// <summary>Creates a Label with custom Html before the label text.  Only starting Html is provided.</summary>
        /// <param name="startHtml">Html to preempt the label text.</param>
        /// <returns>MVC Html for the Label</returns>
        public static MvcHtmlString LabelForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Func<object, HelperResult> startHtml)
        {
            return LabelForCustom(html, expression, startHtml, null, new RouteValueDictionary("new {}"));
        }

        /// <summary>Creates a Label with custom Html before the label text.  Starting Html and a single Html attribute is provided.</summary>
        /// <param name="startHtml">Html to preempt the label text.</param>
        /// <param name="htmlAttributes">A single Html attribute to include.</param>
        /// <returns>MVC Html for the Label</returns>
        public static MvcHtmlString LabelForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Func<object, HelperResult> startHtml, object htmlAttributes)
        {
            return LabelForCustom(html, expression, startHtml, null, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>Creates a Label with custom Html before the label text.  Starting Html and a collection of Html attributes are provided.</summary>
        /// <param name="startHtml">Html to preempt the label text.</param>
        /// <param name="htmlAttributes">A collection of Html attributes to include.</param>
        /// <returns>MVC Html for the Label</returns>
        public static MvcHtmlString LabelForCustom<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, Func<object, HelperResult> startHtml, IDictionary<string, object> htmlAttributes)
        {
            return LabelForCustom(html, expression, startHtml, null, htmlAttributes);
        }

        /// <summary>Creates a Label with custom Html before and after the label text.  Starting Html and ending Html are provided.</summary>
        /// <param name="startHtml">Html to preempt the label text.</param>
        /// <param name="endHtml">Html to follow the label text.</param>
        /// <returns>MVC Html for the Label</returns>
        public static MvcHtmlString LabelForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Func<object, HelperResult> startHtml, Func<object, HelperResult> endHtml)
        {
            return LabelForCustom(html, expression, startHtml, endHtml, new RouteValueDictionary("new {}"));
        }

        /// <summary>Creates a Label with custom Html before and after the label text.  Starting Html, ending Html, and a single Html attribute are provided.</summary>
        /// <param name="startHtml">Html to preempt the label text.</param>
        /// <param name="endHtml">Html to follow the label text.</param>
        /// <param name="htmlAttributes">A single Html attribute to include.</param>
        /// <returns>MVC Html for the Label</returns>
        public static MvcHtmlString LabelForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Func<object, HelperResult> startHtml, Func<object, HelperResult> endHtml, object htmlAttributes)
        {
            return LabelForCustom(html, expression, startHtml, endHtml, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>Creates a Label with custom Html before and after the label text.  Starting Html, ending Html, and a collection of Html attributes are provided.</summary>
        /// <param name="startHtml">Html to preempt the label text.</param>
        /// <param name="endHtml">Html to follow the label text.</param>
        /// <param name="htmlAttributes">A collection of Html attributes to include.</param>
        /// <returns>MVC Html for the Label</returns>
        public static MvcHtmlString LabelForCustom<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, Func<object, HelperResult> startHtml, Func<object, HelperResult> endHtml, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            //Use the DisplayName or PropertyName for the metadata if available.  Otherwise default to the htmlFieldName provided by the user.
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            //Create the new label.
            TagBuilder tag = new TagBuilder("label");

            //Add the specified Html attributes
            tag.MergeAttributes(htmlAttributes);

            //Specify what property the label is tied to.
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            //Run through the various iterations of null starting or ending Html text.
            if (startHtml == null && endHtml == null) tag.InnerHtml = labelText;
            else if (startHtml != null && endHtml == null) tag.InnerHtml = string.Format("{0}{1}", startHtml(null).ToHtmlString(), labelText);
            else if (startHtml == null && endHtml != null) tag.InnerHtml = string.Format("{0}{1}", labelText, endHtml(null).ToHtmlString());
            else tag.InnerHtml = string.Format("{0}{1}{2}", startHtml(null).ToHtmlString(), labelText, endHtml(null).ToHtmlString());

            return MvcHtmlString.Create(tag.ToString());
        }

      

        /// <summary>
        /// Returns an error alert that lists each model error, much like the standard ValidationSummary only with
        /// altered markup for the Twitter bootstrap styles.
        /// </summary>
        public static MvcHtmlString ValidationSummaryBootstrap(this HtmlHelper helper, bool closeable)
        {
            # region Equivalent view markup
            // var errors = ViewData.ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage));
            //
            // if (errors.Count() > 0)
            // {
            //     <div class="alert alert-error alert-block">
            //         <button type="button" class="close" data-dismiss="alert">&times;</button>
            //         <strong>Validation error</strong> - please fix the errors listed below and try again.
            //         <ul>
            //             @foreach (var error in errors)
            //             {
            //                 <li class="text-error">@error</li>
            //             }
            //         </ul>
            //     </div>
            // }
            # endregion

            var errors = helper.ViewContext.ViewData.ModelState.SelectMany(state => state.Value.Errors.Select(error => error.ErrorMessage));

            int errorCount = errors.Count();

            if (errorCount == 0)
            {
                //return new MvcHtmlString(string.Empty);
                return new MvcHtmlString("Nenhum erro encontrado");
            }

            var div = new TagBuilder("div");
            div.AddCssClass("alert");
            div.AddCssClass("alert-error");

            string message;

            if (errorCount == 1)
            {
                message = errors.First();
            }
            else
            {
                message = "Please fix the errors listed below and try again.";
                div.AddCssClass("alert-block");
            }

            if (closeable)
            {
                var button = new TagBuilder("button");
                button.AddCssClass("close");
                button.MergeAttribute("type", "button");
                button.MergeAttribute("data-dismiss", "alert");
                button.SetInnerText("x");
                div.InnerHtml += button.ToString();
            }

            div.InnerHtml += "<strong>Validation error</strong> - " + message;

            if (errorCount > 1)
            {
                var ul = new TagBuilder("ul");

                foreach (var error in errors)
                {
                    var li = new TagBuilder("li");
                    li.AddCssClass("text-error");
                    li.SetInnerText(error);
                    ul.InnerHtml += li.ToString();
                }

                div.InnerHtml += ul.ToString();
            }

            return new MvcHtmlString(div.ToString());
        }

        /// <summary>
        /// Overload allowing no arguments.
        /// </summary>
        public static MvcHtmlString ValidationSummaryBootstrap(this HtmlHelper helper)
        {
            return ValidationSummaryBootstrap(helper, true);
        }
    

    }
}