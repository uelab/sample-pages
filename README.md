# User Empowerment Lab website

The User Empowerment Lab is a research lab at the University of Washington directed by Professor Alexis Hiniker.  Founded in 2017, the User Empowerment Lab focuses on understanding people's frustrations with the online systems they use, and creating designs for systems that support more meaningful human experiences.

This repository contains the User Empowerment Lab's website.

## Website architecture

The User Empowerment Lab's website is written in [Jekyll](https://jekyllrb.com/), [Liquid](https://shopify.github.io/liquid/), and [Bootstrap](https://getbootstrap.com/docs/5.3/getting-started/introduction/).  It is generated from a set of data files and HTML templates and deployed using [GitHub Pages](https://docs.github.com/en/pages).

### File structure

The code for the website lives under the `main` branch in the `/docs` folder.  (Why `\docs`?  See [GitHub Pages | About publishing sources](https://docs.github.com/en/pages/getting-started-with-github-pages/configuring-a-publishing-source-for-your-github-pages-site#about-publishing-sources).)

The file structure is roughly as follows:
```txt
└───docs 
    ├───assets         // CSS and image files used to style the site
    ├───_data          // YML files holding data common to site components
    ├───_includes      // HTML/script files used to generate site components
    ├───_layouts       // HTML/script files used to generate site pages 
    ├───_news          // data files holding news story content and metadata
    ├───_people        // data files holding people content and metadata
    ├───_projects      // data files holding projects content and metadata
    ├───_publications  // data files holding publications content and metadata
    └───_site          // static site files currently being served
```

The file structure is largely dictated by Jekyll.  To learn more about the following directories, you can reference these docs pages in the Jekyll documentation:
- `assets` and `_site`: see https://jekyllrb.com/docs/structure/
- `_data`: see https://jekyllrb.com/docs/datafiles/
- `_includes`: see https://jekyllrb.com/docs/includes/
- `_layouts`: see https://jekyllrb.com/docs/layouts/

### Data model

The data files held in directories like `_people` and `_projects` provide the content used to render the pages according to the templates defined in `_includes` and `_layouts`.  They describe the people involved in the User Empowerment Lab and all the cool stuff they're working on!  The site's data model is the set of properties each of the objects (people, projects, etc.) has, and how they're related to each other.  
