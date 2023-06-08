using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Web.Extensions;

/// <summary>
/// Asp.Net控件对象扩展方法类
/// </summary>
public static class ControlExtensions
{
	/// <summary>
	/// Performs a typed search of a control within the current naming container.
	/// </summary>
	/// <typeparam name="T">The control type</typeparam>
	/// <param name="control">The parent control / naming container to search within.</param>
	/// <param name="id">The id of the control to be found.</param>
	/// <returns>The found control</returns>
	public static T FindControl<T>(this Control control, string id) where T : Control
	{
		return control.FindControl(id) as T;
	}

	/// <summary>
	/// Finds the control.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="control">The root control.</param>
	/// <param name="comparison">The comparison.</param>
	/// <returns>The T</returns>
	public static T FindControl<T>(this Control control, Func<T, bool> comparison) where T : Control
	{
		foreach (Control child in control.Controls)
		{
			T ctl = child as T;
			if (ctl.IsNotNull() && comparison(ctl))
			{
				return ctl;
			}
		}
		return null;
	}

	/// <summary>
	/// Finds a control by its ID recursively
	/// </summary>
	/// <param name="control">The root parent control.</param>
	/// <param name="id">The id of the control to be found.</param>
	/// <returns>The found control</returns>
	public static Control FindControlRecursive(this Control control, string id)
	{
		Control ctl = (from c in control.Controls.OfType<Control>()
			where c.ID.EqualOrdinal(id, ignoreCase: true)
			select c).FirstOrDefault();
		if (ctl.IsNotNull())
		{
			return ctl;
		}
		foreach (Control child in control.Controls)
		{
			ctl = child.FindControlRecursive(id);
			if (ctl.IsNotNull())
			{
				return ctl;
			}
		}
		return null;
	}

	/// <summary>
	///   Finds a control by its ID recursively
	/// </summary>
	/// <typeparam name="T">The control type</typeparam>
	/// <param name="control">The root parent control.</param>
	/// <param name="id">The id of the control to be found.</param>
	/// <returns>The found control</returns>
	public static T FindControlRecursive<T>(this Control control, string id) where T : Control
	{
		T ctl = (from c in control.Controls.OfType<T>()
			where c.ID.EqualOrdinal(id, ignoreCase: true)
			select c).FirstOrDefault();
		if (ctl.IsNotNull())
		{
			return ctl;
		}
		foreach (Control child in control.Controls)
		{
			ctl = child.FindControlRecursive<T>(id);
			if (ctl.IsNotNull())
			{
				return ctl;
			}
		}
		return null;
	}

	/// <summary>
	/// Finds the control recursively.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="control">The root control.</param>
	/// <param name="comparison">The comparison.</param>
	/// <returns>The T</returns>
	public static T FindControlRecursive<T>(this Control control, Func<T, bool> comparison) where T : Control
	{
		foreach (Control child in control.Controls)
		{
			T ctl = child as T;
			if (ctl.IsNotNull() && comparison(ctl))
			{
				return ctl;
			}
		}
		foreach (Control child in control.Controls)
		{
			T ctl = child.FindControlRecursive(comparison);
			if (ctl.IsNotNull())
			{
				return ctl;
			}
		}
		return null;
	}

	/// <summary>
	///   Returns the first matching parent control.
	/// </summary>
	/// <typeparam name="T">The typ of the requested parent control.</typeparam>
	/// <param name="control">The control to start the search on.</param>
	/// <returns>The found control</returns>
	public static T GetParent<T>(this Control control) where T : Control
	{
		for (Control parent = control.Parent; parent != null; parent = parent.Parent)
		{
			if (parent is T)
			{
				return parent as T;
			}
		}
		return null;
	}

	/// <summary>
	///   Returns all direct child controls matching to the supplied type.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="control">The control.</param>
	/// <returns></returns>
	/// <example>
	///   <code>
	///     foreach(var textControl in this.GetChildControlsByType&lt;ITextControl&gt;()) {
	///     textControl.Text = "...";
	///     }
	///   </code>
	/// </example>
	public static IEnumerable<T> GetChildControlsByType<T>(this Control control) where T : Control
	{
		foreach (Control childControl in control.Controls)
		{
			if (childControl is T)
			{
				yield return childControl as T;
			}
		}
	}

	/// <summary>
	///   Sets the visibility of one or more controls
	/// </summary>
	/// <param name="control">The root control.</param>
	/// <param name="controls">The controls to be set visible.</param>
	public static void SetVisibility(this Control control, params Control[] controls)
	{
		control.SetVisibility(visible: true, controls);
	}

	/// <summary>
	///   Sets the visibility of one or more controls
	/// </summary>
	/// <param name="control">The root control.</param>
	/// <param name="visible">if set to <c>true</c> [visible].</param>
	/// <param name="controls">The controls to be set visible.</param>
	public static void SetVisibility(this Control control, bool visible, params Control[] controls)
	{
		Array.ForEach(controls, delegate(Control c)
		{
			c.Visible = visible;
		});
	}

	/// <summary>
	///   Sets the visibility of one or more controls
	/// </summary>
	/// <param name="control">The root control.</param>
	/// <param name="controlIDs">The control IDs.</param>
	public static void SetVisibility(this Control control, params string[] controlIDs)
	{
		control.SetVisibility(visible: true, controlIDs);
	}

	/// <summary>
	///   Sets the visibility of one or more controls
	/// </summary>
	/// <param name="control">The root control.</param>
	/// <param name="visible">if set to <c>true</c> [visible].</param>
	/// <param name="controlIDs">The control IDs.</param>
	public static void SetVisibility(this Control control, bool visible, params string[] controlIDs)
	{
		foreach (string id in controlIDs)
		{
			Control ctl = control.FindControlRecursive(id);
			if (ctl != null)
			{
				ctl.Visible = visible;
			}
		}
	}

	/// <summary>
	///   Sets the visibility of one or more controls
	/// </summary>
	/// <param name="control">The root control.</param>
	/// <param name="condition">The condition.</param>
	/// <param name="controls">The controls to be set visible.</param>
	public static void SetVisibility(this Control control, Predicate<Control> condition, params Control[] controls)
	{
		Array.ForEach(controls, delegate(Control c)
		{
			c.Visible = condition(c);
		});
	}

	/// <summary>
	///   Sets the visibility of one or more controls
	/// </summary>
	/// <param name="control">The root control.</param>
	/// <param name="condition">The condition.</param>
	/// <param name="controlIDs">The control IDs.</param>
	public static void SetVisibility(this Control control, Predicate<Control> condition, params string[] controlIDs)
	{
		foreach (string id in controlIDs)
		{
			Control ctl = control.FindControlRecursive(id);
			if (ctl != null)
			{
				ctl.Visible = condition(ctl);
			}
		}
	}

	/// <summary>
	///   Switches the visibility of two controls.
	/// </summary>
	/// <param name="control">The root control.</param>
	/// <param name="visible">The visible control.</param>
	/// <param name="notVisible">The not visible control.</param>
	public static void SwitchVisibility(this Control control, Control visible, Control notVisible)
	{
		visible.Visible = true;
		notVisible.Visible = false;
	}

	/// <summary>
	/// Runs action delegate for all controls and subcontrols in ControlCollection.
	/// </summary>
	/// <param name="controlCollection">The control collection.</param>
	/// <param name="action">The action.</param>
	/// <remarks></remarks>
	public static void ForEachControl(this ControlCollection controlCollection, Action<Control> action)
	{
		if (controlCollection == null)
		{
			return;
		}
		foreach (Control c in controlCollection)
		{
			action(c);
			if (c.HasControls())
			{
				c.Controls.ForEachControl(action);
			}
		}
	}
}
