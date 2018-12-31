using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Tp.Common.Constants;
using Tp.Common.Extensions.IListExtensions;

namespace Tp.Website.Helpers
{
    public static class ActionButtonHelper
    {
        public static IHtmlContent ActionButtonGroupAddCancel(
            this IHtmlHelper html,
            string idSuffix,
            string addButtonText = null,
            string hrefCancel = null)
        {
            var actionButtons = ActionButtonAdd(idSuffix: idSuffix, buttonText: addButtonText);
            actionButtons.Add(ActionButtonCancel(idSuffix: idSuffix, hrefCancel: hrefCancel));
            return ActionButtonGroup(actionButtons);
        }

        public static IHtmlContent ActionButtonGroupSave(
            this IHtmlHelper html,
            string idSuffix,
            string saveButtonText = null)
        {
            var actionButtons = ActionButtonSave(idSuffix: idSuffix, buttonText: saveButtonText);
            return ActionButtonGroup(actionButtons);
        }

        public static IHtmlContent ActionButtonGroupEdit(
            this IHtmlHelper html,
            string idSuffix,
            string toolTip = null)
        {
            var actionButtons = ActionButtonEdit(idSuffix: idSuffix /*, toolTip: toolTip */);
            return ActionButtonGroup(actionButtons, isPositionBottomRight: true);
        }

        public static IHtmlContent ActionButtonGroupSaveCancel(
            this IHtmlHelper html,
            string idSuffix,
            string saveButtonText = null,
            string hrefCancel = null)
        {
            var actionButtons = ActionButtonSave(idSuffix: idSuffix, buttonText: saveButtonText);
            actionButtons.Add(ActionButtonCancel(idSuffix: idSuffix, hrefCancel: hrefCancel));
            return ActionButtonGroup(actionButtons);
        }

        public static IHtmlContent ActionButtonGroupSaveDelete(
            this IHtmlHelper html,
            string idSuffix,
            string saveButtonText = null,
            string deleteButtonText = null)
        {
            var actionButtons = ActionButtonSave(idSuffix: idSuffix, buttonText: saveButtonText);
            foreach (var button in ActionButtonDelete(idSuffix: idSuffix, buttonText: deleteButtonText))
            {
                actionButtons.Add(button);
            }
            return ActionButtonGroup(actionButtons);
        }

        public static IHtmlContent ActionButtonGroupSaveDeleteCancel(
            this IHtmlHelper html,
            string idSuffix,
            string saveButtonText = null,
            string deleteButtonText = null,
            string hrefCancel = null)
        {
            var actionButtons = ActionButtonSave(idSuffix: idSuffix, buttonText: saveButtonText);
            actionButtons.AddRange(ActionButtonDelete(idSuffix: idSuffix, buttonText: deleteButtonText));
            actionButtons.Add(ActionButtonCancel(idSuffix, hrefCancel));
            return ActionButtonGroup(actionButtons);
        }

        private static IHtmlContent ActionButtonGroup(IList<TagBuilder> buttons, bool isPositionBottomRight = false)
        {
            var tbSpan = new TagBuilder("span");
            tbSpan.AddCssClass("action-button-group");

            if (isPositionBottomRight)
            {
                tbSpan.AddCssClass("action-button-group--position-bottom-right");
            }

            var space = "";
            foreach (var button in buttons)
            {
                tbSpan.InnerHtml.Append(space);
                tbSpan.InnerHtml.AppendHtml(button);
                space = " ";
            }

            return tbSpan;
        }

        private static IList<TagBuilder> ActionButtonAdd(string idSuffix, string buttonText)
        {
            return new List<TagBuilder>
            {
                ActionButton(
                    defaultText: "Add",
                    buttonText: buttonText,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Add,
                    buttonType: BootstrapContext.Primary,
                    id: "js-add-" + idSuffix,
                    ////toolTip: null,
                    href: null,
                    action: null),
                ActionButton(
                    defaultText: "Adding",
                    buttonText: buttonText,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Adding,
                    buttonType: BootstrapContext.Primary,
                    id: null,
                    ////toolTip: null,
                    href: null,
                    action: "saving")
            };
        }

        private static IList<TagBuilder> ActionButtonEdit(string idSuffix /*, string toolTip*/)
        {
            return new List<TagBuilder>
            {
                ActionButton(
                    defaultText: null,
                    buttonText: null,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Edit,
                    buttonType: BootstrapContext.Success,
                    ////toolTip: toolTip,
                    id: "js-edit-" + idSuffix,
                    href: null,
                    action: null),
                ActionButton(
                    defaultText: "Loading",
                    buttonText: null,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Editing,
                    buttonType: BootstrapContext.Success,
                    id: null,
                    ////toolTip: null,
                    href: null,
                    action: "editing")
            };
        }

        private static IList<TagBuilder> ActionButtonSave(string idSuffix, string buttonText)
        {
            return new List<TagBuilder>
            {
                ActionButton(
                    defaultText: "Save",
                    buttonText: buttonText,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Save,
                    buttonType: BootstrapContext.Primary,
                    id: "js-save-" + idSuffix,
                    ////toolTip: null,
                    href: null,
                    action: null),
                ActionButton(
                    defaultText: "Saving",
                    buttonText: buttonText,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Saving,
                    buttonType: BootstrapContext.Primary,
                    id: null,
                    ////toolTip: null,
                    href: null,
                    action: "saving")
            };
        }

        private static IList<TagBuilder> ActionButtonDelete(string idSuffix, string buttonText)
        {
            return new List<TagBuilder>
            {
                ActionButton(
                    defaultText: "Delete",
                    buttonText: buttonText,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Delete,
                    buttonType: BootstrapContext.Danger,
                    id: "js-delete-" + idSuffix,
                    ////toolTip: null,
                    href: null,
                    action: null),
                ActionButton(
                    defaultText: "Deleting",
                    buttonText: buttonText,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Deleting,
                    buttonType: BootstrapContext.Danger,
                    id: null,
                    ////toolTip: null,
                    href: null,
                    action: "deleting")
            };
        }

        private static TagBuilder ActionButtonCancel(string idSuffix, string hrefCancel)
        {
            return
                ActionButton(
                    defaultText: "Cancel",
                    buttonText: null,
                    fontAwesomeIcon: FontAwesomeIconActionButton.Cancel,
                    buttonType: BootstrapContext.Default,
                    id: "js-cancel-" + idSuffix,
                    ////toolTip: null,
                    href: hrefCancel,
                    action: null);
        }

        private static TagBuilder ActionButton(
            string defaultText,
            string buttonText,
            string fontAwesomeIcon,
            BootstrapContext buttonType,
            ////string toolTip,
            string id,
            string href,
            string action)
        {
            if (buttonText == null)
            {
                buttonText = defaultText;
            }
            else
            {
                buttonText = defaultText + " " + buttonText;
            }

            var tbIcon = new TagBuilder("i");
            tbIcon.AddCssClass("fa");
            tbIcon.AddCssClass("fa-" + fontAwesomeIcon);
            if (fontAwesomeIcon == "spinner")
            {
                tbIcon.AddCssClass("fa-spin");
            }
            if (!string.IsNullOrWhiteSpace(buttonText)) tbIcon.AddCssClass("icon-offset");

            var tb = new TagBuilder(href == null ? "button" : "a");

            if (href == null)
            {
                tb.MergeAttribute("type", "button");
            }
            else
            {
                tb.MergeAttribute("href", href);
            }

            tb.AddCssClass("btn");
            tb.AddCssClass("btn-" + buttonType.ToString().ToLower());
            tb.AddCssClass("action-button-group__button");
            if (action != null)
            {
                tb.AddCssClass("action-button-group__button--is-" + action);
            }

            ////if (toolTip != null)
            ////{
            ////    tb.MergeAttributes(ToolTipAttrs.Create(toolTip, placement: ToolTipAttrs.PlacementOption.Right));
            ////}

            if (id != null)
            {
                tb.GenerateId(id, "_");
            }

            tb.InnerHtml.AppendHtml(tbIcon);
            tb.InnerHtml.Append(buttonText);

            return tb;
        }
    }
}