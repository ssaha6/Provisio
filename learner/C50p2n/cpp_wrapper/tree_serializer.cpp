#include <ostream>
#include <cstring>
#include <string>
#include <sstream>

extern "C" {
#include "defns.i"
#include "extern.i"

#include "tree_serializer.h"
}

/**
 * Translates a C5 decision tree into a JSON serialization.
 *
 * @param t The C5 decision tree to serialize
 * @param out An output stream to serialize to
 */
void _serialize_to_JSON (Tree t, std::ostream & out) {

	// We can only handle leafs, continuous attributes, or discrete attributes
	assert (!t->NodeType || (t->NodeType == BrThresh && Continuous (t->Tested)) || (t->NodeType == BrDiscr && Discrete (t->Tested)));
	
	// Start of class
	out << "{";
		
	//if leaf node
	if (!t->NodeType) {

		//Condition
		out << "\"conditions\":[],"; 

		// Classification
		out << "\"classification\":" << ClassName[t->Leaf] << ",";

		// Children
		out << "\"children\":null";

	}
	else 
	{	
		// Starting of conditions
		out <<"\"conditions\": [{"; 

		// Attribute
		out << "\"attribute\":\"" << AttName[t->Tested] << "\",";

		//Node types
		switch(t->NodeType)
		{
			case BrThresh:

				// Comparison			
				out << "\"comparison\":\"<=\",";

				// Cut
				char some_char_array[20];
				CValToStr(t->Cut, t->Tested, some_char_array);
				out << "\"cut\":" << some_char_array ;
				break; 

			case BrDiscr:
				
				//Shambo: instead using partition for discrete values
				out << "\"partition\":\""  << AttValName[t->Tested][2] << "\"";
				break; 
		}

		//End of conditions
		out << "}],";

		// Classification
		//out << "\"classification\":0,";

		// Children
		out << "\"children\":[";
		for (int i = 2; i <= t->Forks; i++) 
		{
			_serialize_to_JSON (t->Branch[i], out);
			out << (i != t->Forks ? "," : "");
		}
		out << "]";

	}
	
	// End of class
	out << "}";

}

char * serialize_to_JSON (Tree t) {

	std::stringstream out;
	_serialize_to_JSON (t, out);

	std::string str = out.str ();
	char * cstr = (char *) malloc ((str.length ()+1) * sizeof(char));
  	std::strcpy (cstr, str.c_str ());

	return cstr;

}



//Shambo: added: serialize rules to json
void _serialize_condition(Condition C, std::ostream & out){

	// Value
	DiscrValue v;
	v = C->TestValue;

	//Attribute=
	Attribute Att;
	Att = C->Tested;

	//Starting of condition
	out << "{"; 

	//Attribute
	out << "\"attribute\":\"" << AttName[Att] << "\",";

	//Node type
	switch (C->NodeType)
	{
		case BrDiscr:
					//Partition for discrete types
					out << "\"partition\":\""  << AttValName[Att][v] << "\"";
					break; 

		case BrThresh:
					//Comparison
					out << "\"comparison\":\"" << ( v == 2 ? "<=" : ">" ) << "\",";

					//cut
					char some_char_array[20];
					CValToStr(C->Cut, Att, some_char_array);
					out << "\"cut\":" << some_char_array ;
					break; 
					
	}
	// end of comparison
	out << "}"; 
}

void _serialize_to_JSON_RULES(CRuleSet RS, std::ostream &out, int index = 1)
{
    int	ri;
	CRule R;
	int	d;
	
	//starting of node
	out << "{";

	//current index ri, and current rule
	ri = index; 
	R = (RS->SRule[ri]);

	//condition
	out << "\"conditions\" : [ ";
	
	ForEach(d, 1, R->Size)
	{	
		_serialize_condition(R->Lhs[d], out); 
		if (d < R->Size) out << ","; 
	}
	out << "], ";
		

	//Left Child including Classification
	out << "\"children\": [{\"conditions\":[],\"classification\":" << ClassName[R->Rhs] << ",\"children\":null},";
		
	if (ri < RS->SNRules)
	{
		//Right child new node	
		_serialize_to_JSON_RULES(RS, out, ri+1); 
	}
	else if ( ri == RS->SNRules)
	{
		//Right child default node
		out << "{\"conditions\":[],\"classification\":" <<  ClassName[RS->SDefault] << ",\"children\":null}";
	}

	//end of node
	out << "]}";
}

char * serialize_to_JSON_RULES(CRuleSet r)
{
	std::stringstream out;
	_serialize_to_JSON_RULES(r, out);

	std::string str = out.str();
	char *cstr = (char *)malloc((str.length() + 1) * sizeof(char));
	std::strcpy(cstr, str.c_str());

	return cstr;
}