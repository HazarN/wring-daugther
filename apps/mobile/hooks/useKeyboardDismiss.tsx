import { Keyboard, TouchableWithoutFeedback } from 'react-native';

export function useKeyboardDismiss() {
  type Props = { children: React.ReactNode };
  const Wrapper: React.FC<Props> = ({ children }) => (
    <TouchableWithoutFeedback accessible={false} onPress={() => Keyboard.dismiss()}>
      {children}
    </TouchableWithoutFeedback>
  );

  return Wrapper;
}
