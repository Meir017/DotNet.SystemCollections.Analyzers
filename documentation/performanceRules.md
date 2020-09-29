# Performance (SCA000-)

Rule ID | Title | Enabled | Severity | CodeFix | Description |
--------|-------|---------|----------|---------|----|
SCA001 | Do not use Any for ICollection-based collections.| True | Warning | False | All ICollections should use the Count property and compare it to 0 instead of using the Enumerable.Any() extension method.
SCA002 | Do not use Contains for IEnumerable-based collections.| True | Warning | False | All IEnumerable expressions that require to determine the presence of a specific value should leave the work to a specialized collection like `Dictionary<TKey, TValue>` or even `HashSet<T>` instead of using the Enumerable.Contains() extension method.
SCA003 | Do not use Count for ICollection-based collections.| True | Warning | False | All ICollections should use the Count property instead using of the Enumerable.Count() extension method.
SCA004 | Do not use Distinct for IEnumerable-based collections.| True | Warning | False | Instead of using the Distinct extension method, which is linear `O(n)`, use a set-based collection (i.e. `HashSet<T>`) instead. They have a constant time (i.e. `O(1)`) lookups and additions are `O(1)` while the size doesn't exceeds the capacity, otherwise it's `O(n)`.
SCA005 | Do not use ElementAt or ElementAtOrDefault for IList-based collections.| True | Warning | False | All IList collections can access any item by using the Item indexer property which is a `O(1)` operation instead using of the Enumerable.ElementAt() or Enumerable.ElementAt() extension method.
SCA006 | Do not use First or FirstOrDefault for IList-based collections.| True | Warning | False | All ICollections should use the Count property and compare it to 0 instead of using the Enumerable.Any() extension method.
SCA007 | Do not use Last or LastOrDefault for IList-based collections.| True | Warning | False | All IList should access their last item directly instead using of the Enumerable.Last()/Enumerable.LastOrDefault() extension method.
SCA008 | Do not use LongCount for ICollection-based collections.| True | Warning | False | All ICollections should use the Count property and compare it to 0 instead of using the Enumerable.Any() extension method.
SCA009 | Do not use Single or SingleOrDefault for ICollection-based collections.| True | Warning | False | Use the Count property of the collection to validate that it's the only item instead of using the Enumerable.Single/Enumerable.SingleOrDefault extension method.