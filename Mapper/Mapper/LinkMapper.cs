using Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Service.Mapper.Mapper
{
    public static class LinkMapper
    {       
        public static List<Link> LinkDtosToLinks(this List<string> reflinks, List<string> medialinks)
        {
            List<Link> links = reflinks.Select(x => new Link { Url = x, LinkType = LinkType.Reference }).ToList();
            links.AddRange(medialinks.Select(x => new Link { Url = x, LinkType = LinkType.Media }).ToList());
            return links;
        }

        public static List<string> LinksToReferenceLinks(this List<Link> links)
        {
            List<string> referenceLinks =links.Where(a => a.LinkType == LinkType.Reference).Select(l => l.Url).ToList();
            return referenceLinks;
        }

        public static List<string> LinksToMediaLinks(this List<Link> links)
        {
            List<string> mediaLinks = links.Where(a => a.LinkType == LinkType.Media).Select(l => l.Url).ToList();
            return mediaLinks;
        }
    }
}