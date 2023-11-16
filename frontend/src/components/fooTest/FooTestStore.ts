import FooTestApi from "./FooTestApi";

export class TestStore {
  someData = [] as string[];

  addSomeData(someString: string) {
    this.someData.push(someString);
  }

  clearData() {
    this.someData = [];
  }

  async sendApi(): Promise<void> {
    await FooTestApi.send();
  }
}

const store = new TestStore();
export default store;
