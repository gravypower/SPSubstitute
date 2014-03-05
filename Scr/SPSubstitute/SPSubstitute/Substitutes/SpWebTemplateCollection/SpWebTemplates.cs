namespace SPSubstitute.Substitutes.SpWebTemplateCollection
{
    using System.Collections.Generic;

    public class SpWebTemplates
    {
        public SpWebTemplates()
        {
           this.templates = new Dictionary<uint, SubstituteSpWebTemplateCollection>();
        }

        private readonly Dictionary<uint, SubstituteSpWebTemplateCollection> templates;
        public SubstituteSpWebTemplateCollection this[uint lcid]
        {
            get
            {
                if (!this.templates.ContainsKey(lcid))
                    this.templates.Add(lcid, new SubstituteSpWebTemplateCollection());

                return this.templates[lcid];
            }
        }
    }
}
