using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using OpenLigaDBClasses;

namespace OpenLigaDB
{
    public class OpenLigaDBApi
    {
        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.openligadb.de/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static List<Match> GetMatchesForCurrentMatchday(string league)
        {
            return GetFromPath<List<Match>>($"api/getmatchdata/{league}");
        }

        public static List<Match> GetMatchesForMatchday(string league, int matchDay, int seasonStartYear)
        {
            return GetFromPath<List<Match>>($"api/getmatchdata/{league}/{seasonStartYear}/{matchDay}");
        }

        public static List<Match> GetMatchesForSeason(string league, int seasonStartYear)
        {
            return GetFromPath<List<Match>>($"api/getmatchdata/{league}/{seasonStartYear}");
        }

        public static Match GetMatchForId(int matchId)
        {
            return GetFromPath<Match>($"api/getmatchdata/{matchId}");
        }

        public static Group GetCurrentGroup(string league)
        {
            return GetFromPath<Group>($"api/getcurrentgroup/{league}");
        }

        public static List<Group> GetAvailableGroups(string league, int seasonStartYear)
        {
            return GetFromPath<List<Group>>($"api/getavailablegroups/{league}/{seasonStartYear}");
        }

        public static List<Team> GetAvailableTeams(string league, int seasonStartYear)
        {
            return GetFromPath<List<Team>>($"api/getavailableteams/{league}/{seasonStartYear}");
        }

        public static List<GoalGetter> GetGoalGetters(string league, int seasonStartYear)
        {
            return GetFromPath<List<GoalGetter>>($"api/getgoalgetters/{league}/{seasonStartYear}");
        }

        public static List<Team> GetTable(string league, int seasonStartYear)
        {
            return GetFromPath<List<Team>>($"api/getbltable/{league}/{seasonStartYear}");
        }

        private static T GetFromPath<T>(string path)
        {
            using (var client = GetHttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    return GetFromResponse<T>(responseString);
                }
            }
            return default;
        }

        private static T GetFromResponse<T>(string responseString)
        {
            return (T)JsonConvert.DeserializeObject(responseString, typeof(T),
                            new JsonSerializerSettings()
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
        }
    }
}