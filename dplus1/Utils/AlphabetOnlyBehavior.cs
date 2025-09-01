using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dplus1.Utils
{
    public class AlphabetOnlyBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object? sender, TextChangedEventArgs e)
        {
            if (sender == null) return;

            var entry = (Entry)sender;
            string newText = e.NewTextValue;

            if (!string.IsNullOrEmpty(newText))
            {
                string validText = new string(newText.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                if (entry.Text != validText)
                {
                    entry.Text = validText;
                }
            }
        }
    }
}
