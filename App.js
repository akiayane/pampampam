import React, { useState } from 'react'
import { StyleSheet, View, FlatList} from 'react-native'
import { Navbar } from './src/Navbar'
import { AddTodo } from './src/AddTodo'
import { Todo } from './src/Todo'

export default function App() {
  const [todos, setTodos] = useState([
    {id: 1, title: 'text'},
    {id: 2, title: 'text'},
    {id: 3, title: 'text'},
    {id: 4, title: 'text'},
    {id: 5, title: 'text'},
    {id: 6, title: 'text'},
    {id: 7, title: 'text'},
  ])

  const addTodo = title => {
        setTodos(prevTodos => [
      ...prevTodos,
      { 
        id: Math.random().toString(),
        title
      }
    ])
  }

  const removeTodo = id => {
    setTodos(prev => prev.filter(todo => todo.id !== id))
  }

  return (
    <View>
     <Navbar title="Todo App"/>
     <View style={styles.container}>
     <AddTodo onSubmit={addTodo} />
     <FlatList
     keyExtractor={item => item.id.toString()}
     data ={todos}
     renderItem={({item}) => (
      <Todo todo={item} onRemove={removeTodo}/>
     )}
     />
     </View>
    </View>
  );
}
 
const styles = StyleSheet.create({
  container: {
    paddingHorizontal: 30,
    paddingVertical: 20
  }
});
