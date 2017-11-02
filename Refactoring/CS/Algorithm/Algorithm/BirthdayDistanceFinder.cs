using System.Collections.Generic;

namespace Algorithm
{
    public class BirthdayDistanceFinder
    {
        private readonly List<Person> _persons;

        public BirthdayDistanceFinder(List<Person> persons)
        {
            _persons = persons;
        }

        /// <summary>Find the 2 people with the closest or farthest birthdays from each other as defined by distance
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public OrderedPersonPair Find(BirthdayDistance distance)
        {
            OrderedPersonPair result = null;
            OrderedPersonPair newPair = null;

            for (int i = 0; i < _persons.Count - 1; i++)
            {
                for(int j = i + 1; j < _persons.Count; j++)
                {
                    newPair = new OrderedPersonPair(_persons[i], _persons[j]);
                    result = result ?? newPair;

                    switch (distance)
                    {
                        case BirthdayDistance.ClosestBirthdays:
                            result = newPair.CompareTo(result) == -1 ? newPair : result;
                            break;

                        case BirthdayDistance.FarthestBirthdays:
                            result = newPair.CompareTo(result) == 1 ? newPair : result;
                            break;
                    }
                }
            }
            return result ?? new OrderedPersonPair();
        }
    }
}