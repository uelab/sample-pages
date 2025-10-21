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

## FAQ

### How can I get set up to contribute to the site?

1. Set up GitHub
2. Set up Ruby (TODO: is this needed to keep _site files up to date?)

### How can I myself as a person to the site or update my person profile?

1. Where are the people files
2. What is the meta-data required (TODO: do we need a separate data model README?)

### How can I add a project or publication to the site?